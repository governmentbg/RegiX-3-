<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/BABH/BABHZhS/RegisteredAnimalsInOEZByCategoryRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.BABHZhSAdapter\XMLSchemas\RegisteredAnimalsInOEZByCategoryRequest.xsd" workingxmlfile="RegisteredAnimalsInOEZByCategoryRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:RegisteredAnimalsInOEZByCategoryRequest" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Входни параметри на справка за животни в ОЕЗ "/>										</children>									</paragraph>									<table>										<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>										<children>											<tablebody>												<children>													<tablerow>														<children>															<tablecell>																<properties width="355"/>																<children>																	<text fixtext="ЕГН/Булстат">																		<styles font-style="italic" font-weight="normal"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:Identifier" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>													<tablerow>														<children>															<tablecell>																<properties width="355"/>																<children>																	<text fixtext="Дата на актуалност на данните">																		<styles font-style="italic" font-weight="normal"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:ValidDate" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format string="DD.MM.YYYY hh:mm:ss" datatype="dateTime"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>												</children>											</tablebody>										</children>									</table>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>