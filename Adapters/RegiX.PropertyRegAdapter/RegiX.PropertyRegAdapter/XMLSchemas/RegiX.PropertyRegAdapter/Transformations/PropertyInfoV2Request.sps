<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/AV/PropertyReg/PropertyInfoV2Request"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.PropertyRegAdapter\XMLSchemas\PropertyInfoV2Request.xsd" workingxmlfile="PropertyInfoV2Request.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:PropertyInfoV2Request" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Входни данни на справка по имот - V2"/>										</children>									</paragraph>									<table>										<properties border="0" cellpadding="0" cellspacing="0" class="table-responsive" width="100%"/>										<children>											<tablebody>												<children>													<tablerow>														<children>															<tablecell>																<properties width="360"/>																<children>																	<text fixtext="Системен идентификатор на имот:">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:PropertyID" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>													<tablerow>														<children>															<tablecell>																<properties width="360"/>																<children>																	<text fixtext="От дата:">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:DateFrom" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>													<tablerow>														<children>															<tablecell>																<properties width="360"/>																<children>																	<text fixtext="До дата:">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:DateTo" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>													<tablerow>														<children>															<tablecell>																<properties width="360"/>																<children>																	<text fixtext="Идентификатор на служба по вписванията:">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:SiteID" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>												</children>											</tablebody>										</children>									</table>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>