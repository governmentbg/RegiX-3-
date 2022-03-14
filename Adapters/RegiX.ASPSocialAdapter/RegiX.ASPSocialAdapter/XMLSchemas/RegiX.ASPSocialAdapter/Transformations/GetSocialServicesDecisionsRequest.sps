<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/ASP/Common"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/ASP/SocialServices/GetSocialServicesDecisionsRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="..\GetSocialServicesDecisionsRequest.xsd" workingxmlfile="GetSocialServicesDecisionsRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Входни параметри на справка по ЕГН/ЛНЧ за издадени заповеди за ползване на социални услуги"/>								</children>							</paragraph>							<template match="n1:GetSocialServicesDecisionsRequest" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<template match="n1:PersonData" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<newline/>											<table>												<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>												<children>													<tablebody>														<children>															<tablerow>																<children>																	<tablecell>																		<properties width="176"/>																		<children>																			<text fixtext="Тип на идентификатор:">																				<styles font-style="italic"/>																			</text>																		</children>																	</tablecell>																	<tablecell>																		<children>																			<template match="common:IdentifierType" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<condition>																						<children>																							<conditionbranch xpath=". = &quot;EGN&quot;">																								<children>																									<text fixtext="ЕГН">																										<styles font-weight="bold"/>																									</text>																								</children>																							</conditionbranch>																							<conditionbranch xpath=". = &quot;LNCh&quot;">																								<children>																									<text fixtext="ЛНЧ">																										<styles font-weight="bold"/>																									</text>																								</children>																							</conditionbranch>																						</children>																					</condition>																				</children>																			</template>																		</children>																	</tablecell>																</children>															</tablerow>															<tablerow>																<children>																	<tablecell>																		<properties width="175"/>																		<children>																			<text fixtext="Идентификатор:">																				<styles font-style="italic"/>																			</text>																		</children>																	</tablecell>																	<tablecell>																		<children>																			<template match="common:Identifier" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<content>																						<styles font-weight="bold"/>																						<format datatype="string"/>																					</content>																				</children>																			</template>																		</children>																	</tablecell>																</children>															</tablerow>														</children>													</tablebody>												</children>											</table>										</children>									</template>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>