<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/GRAO/LE"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/GRAO/LE/LocationsRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.GraoLEAdapter\XMLSchemas\LocationsRequest.xsd" workingxmlfile="LocationsRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:LocationsRequest" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Входни параметри на справка за локализационни единици"/>										</children>									</paragraph>									<table>										<properties border="0" cellpadding="0" cellspacing="0" width="100%"/>										<children>											<tablebody>												<children>													<tablerow>														<children>															<tablecell>																<properties width="274"/>																<styles padding="4px" vertical-align="top"/>																<children>																	<text fixtext="Начална дата:">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<properties align="left"/>																<styles padding="4px" vertical-align="top"/>																<children>																	<template match="n1:StartDate" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format string="DD.MM.YYYY" datatype="date"/>																			</content>																			<text fixtext=" г."/>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>													<tablerow>														<children>															<tablecell>																<properties width="274"/>																<styles padding="4px" vertical-align="top"/>																<children>																	<text fixtext="Крайна дата:">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<properties align="left"/>																<styles padding="4px" vertical-align="top"/>																<children>																	<template match="n1:EndDate" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format string="DD.MM.YYYY" datatype="date"/>																			</content>																			<text fixtext=" г."/>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>													<tablerow>														<children>															<tablecell>																<properties width="274"/>																<styles padding="4px" vertical-align="top"/>																<children>																	<text fixtext="Вид актуализационен запис (ДПА, ИПА и КПА):">																		<styles font-style="italic"/>																	</text>																</children>															</tablecell>															<tablecell>																<properties align="left"/>																<styles padding="4px" vertical-align="top"/>																<children>																	<template match="n1:ActualizationType" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>												</children>											</tablebody>										</children>									</table>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>